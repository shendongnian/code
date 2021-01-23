    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Windows;
    using System.Linq;
    using System.Windows.Markup;
    using Trace.Lib;
    
    namespace Atlas.SSUP.Client.Core.Components.Managers
    {
    	public class StringManager
    	{
    		public static readonly StringManager Instance = new StringManager();
    
    		/// <summary>
    		/// Private constructor for singleton pattern
    		/// </summary>
    		private StringManager()
    		{
    		}
    
    		private readonly CultureInfo DefaultCulture = new CultureInfo("fr-FR");
    
    		private ResourceDictionary LanguageDictionary { get; set; }
    
    		private Collection<ResourceDictionary> Root
    		{
    			get { return Application.Current.Resources.MergedDictionaries[0].MergedDictionaries; }
    		}
    
    		/// <summary>
    		/// Gets a string from the common resource file.
    		/// </summary>
    		/// <param name="key">The key.of the desired string.</param>
    		/// <returns>The string corresponding to the key provided.</returns>
    		public string GetString(string key)
    		{
    			try
    			{
    				string value = LanguageDictionary[key] as string;
    				if (value == null || value.Contains("String.Empty"))
    					value = string.Empty;
    
    				return value;
    			}
    			catch (Exception e)
    			{
                    BusinessLogger.Manage(e);
    				return string.Empty;
    			}
    		}
    
    		public void SetCulture( string newSource )
    		{
    			try
    			{
    				ResourceDictionary langOld = Root.Single(p => p.Source.OriginalString.Contains("Strings."));
    				if (langOld != null)
    				{
    					ResourceDictionary lang = LoadDictionary(newSource);
    					if (lang != null)
    					{
    
    						Application.Current.Resources.BeginInit();
    
    						Root.Remove(langOld);
    						Root.Insert(0,lang);
    
    						Application.Current.Resources.EndInit();
    
    						LanguageDictionary = lang;
    					}
    				}
    			}
    			catch (Exception e)
    			{
                    BusinessLogger.Manage(e);
    				throw;
    			}
    		}
    
    
    		public void Load()
    		{
    			Collection<ResourceDictionary> toRemove = new Collection<ResourceDictionary>();
    			Collection<ResourceDictionary> toAdd = new Collection<ResourceDictionary>();
    
    			foreach (ResourceDictionary res in Root)
    			{
    				if (res.Source.OriginalString.Contains("/Atlas.SSUP.Client.Core;Component/Resources/"))
    				{
    					ResourceDictionary newDico = LoadDictionary(res.Source.OriginalString.Replace("/Atlas.SSUP.Client.Core;Component/Resources/", ""));
    					if (newDico != null)
    					{
    						toAdd.Add(newDico);
    						toRemove.Add(res);
    					}
    				}
    			}
    	
    			Application.Current.Resources.BeginInit();
    
    			foreach (ResourceDictionary res in toRemove)
    				Root.Remove(res);
    			foreach (ResourceDictionary res in toAdd)
    				Root.Add(res);
    
    			Application.Current.Resources.EndInit();
    		}
    
    		private ResourceDictionary LoadDictionary(string source)
    		{
    			Stream streamInfo = null;
    			ResourceDictionary dictionary = null;
    
    			try
    			{
    				streamInfo = DistantManager.Instance.GetResource(source);
    
    				if (streamInfo != null)
    				{
    					Uri baseUri = DistantManager.Instance.GetUri(source);
    
    					dictionary = XamlReader.Load(streamInfo) as ResourceDictionary;
    
    					dictionary.Source = baseUri;
    				}
    			}
    			catch (Exception e)
    			{
                    BusinessLogger.Manage(e);
    				return null;
    			}
    
    			return dictionary;
    		}
    	}
    }
