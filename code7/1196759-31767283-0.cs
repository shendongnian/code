    using System;
    using System.IO;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var fileContents = ReadFile();
                Console.ReadLine();  // cause program to pause at the end
            }
    
            public static string ReadFile()
            {
                try
                {
                    using (var streamReader = new StreamReader(
                        @"C:\MyTestFile.txt"))
                    {
                        var fileContents = streamReader.ReadToEnd();
                        Console.WriteLine("File was read successfully");
                        return fileContents;
                    }
                }
                catch (FileNotFoundException fileNotFoundException)
                {
                    LogReadFileException(fileNotFoundException);
                }
                catch (DirectoryNotFoundException directoryNotFoundException)
                {
                    LogReadFileException(directoryNotFoundException);
                }
                catch (IOException ioException)
                {
                    LogReadFileException(ioException);
                }
                // If we get here, an exception occurred
                Console.WriteLine("File could not be read successfully");
                return string.Empty;
            }
    
            private static void LogReadFileException(Exception exception)
            {
                string logFilePath = @"C:\MyLogFile.txt";
    
                using (var streamWriter = new StreamWriter(logFilePath, 
                    append: true))
                {
                    var errorMessage = "Exception occurred:  " +
                        exception.Message;
                    streamWriter.WriteLine(errorMessage);
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
