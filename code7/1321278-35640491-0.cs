    using ConsoleApplication6.Translations.French;
    using System;
    using System.Resources;
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(SystemMessagesManager.GetString("Title"));
                Console.ReadLine();
            }
           public static class SystemMessagesManager
           {
               static ResourceManager rsManager;
               static SystemMessagesManager()
               {
                   //Get the current manager based on the current Culture
                  if (Thread.CurrentThread.CurrentCulture.Name == "fr-FR")
                       rsManager = SystemMessagesFrench.ResourceManager;
                  else if (Thread.CurrentThread.CurrentCulture.Name == "el-GR")
                       rsManager = SystemMessagesGreek.ResourceManager;
                  else
                       rsManager = SystemMessagesEnglish.ResourceManager;
               }
               public static string GetString(string Key)
               {
                   return rsManager.GetString(Key);
               }
           }
       }
    }
