    namespace ClassLibrary
    {
        using Microsoft.Extensions.Configuration;
        using Newtonsoft.Json;
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Reflection;
    
        /// <summary>
        /// A JSON file based <see cref="ConfigurationProvider"/> for embedded resources.
        /// </summary>
        public class SettingsConfigurationProvider : ConfigurationProvider
        {
            /// <summary>
            /// Initializes a new instance of <see cref="SettingsConfigurationProvider"/>.
            /// </summary>
            /// <param name="name">Name of the JSON configuration file.</param>
            /// <param name="optional">Determines if the configuration is optional.</param>
            public SettingsConfigurationProvider(string name)
                : this(name, false)
            {
            }
    
            /// <summary>
            /// Initializes a new instance of <see cref="SettingsConfigurationProvider"/>.
            /// </summary>
            /// <param name="name">Name of the JSON configuration file.</param>
            /// <param name="optional">Determines if the configuration is optional.</param>
            public SettingsConfigurationProvider(string name, bool optional)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Name must be a non-empty string.", nameof(name));
                }
    
                this.Optional = optional;
                this.Name = name;
            }
    
            /// <summary>
            /// Gets a value that determines if this instance of <see cref="SettingsConfigurationProvider"/> is optional.
            /// </summary>
            public bool Optional { get; }
    
            /// <summary>
            /// The name of the file backing this instance of <see cref="SettingsConfigurationProvider"/>.
            /// </summary>
            public string Name { get; }
    
            /// <summary>
            /// Loads the contents of the embedded resource with name <see cref="Path"/>.
            /// </summary>
            /// <exception cref="FileNotFoundException">If <see cref="Optional"/> is <c>false</c> and a
            /// resource does not exist with name <see cref="Path"/>.</exception>
            public override void Load()
            {
                Assembly assembly = Assembly.GetAssembly(typeof(SettingsConfigurationProvider));
                var resourceName = $"{assembly.GetName().Name}.{this.Name}";
                var resources = assembly.GetManifestResourceNames();
    
                if (!resources.Contains(resourceName))
                {
                    if (Optional)
                    {
                        Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                    }
                    else
                    {
                        throw new FileNotFoundException($"The configuration file with name '{this.Name}' was not found and is not optional.");
                    }
                }
                else
                {
                    using (Stream settingsStream = assembly.GetManifestResourceStream(resourceName))
                    {
                        Load(settingsStream);
                    }
                }
            }
    
            internal void Load(Stream stream)
            {
                JsonConfigurationFileParser parser = new JsonConfigurationFileParser();
                try
                {
                    Data = parser.Parse(stream);
                }
                catch (JsonReaderException e)
                {
                    string errorLine = string.Empty;
                    if (stream.CanSeek)
                    {
                        stream.Seek(0, SeekOrigin.Begin);
    
                        IEnumerable<string> fileContent;
                        using (var streamReader = new StreamReader(stream))
                        {
                            fileContent = ReadLines(streamReader);
                            errorLine = RetrieveErrorContext(e, fileContent);
                        }
                    }
    
                    throw new FormatException($"Could not parse the JSON file. Error on line number '{e.LineNumber}': '{e}'.");
                }
            }
    
            private static string RetrieveErrorContext(JsonReaderException e, IEnumerable<string> fileContent)
            {
                string errorLine;
                if (e.LineNumber >= 2)
                {
                    var errorContext = fileContent.Skip(e.LineNumber - 2).Take(2).ToList();
                    errorLine = errorContext[0].Trim() + Environment.NewLine + errorContext[1].Trim();
                }
                else
                {
                    var possibleLineContent = fileContent.Skip(e.LineNumber - 1).FirstOrDefault();
                    errorLine = possibleLineContent ?? string.Empty;
                }
    
                return errorLine;
            }
    
            private static IEnumerable<string> ReadLines(StreamReader streamReader)
            {
                string line;
                do
                {
                    line = streamReader.ReadLine();
                    yield return line;
                } while (line != null);
            }
        }
    }
