     using System;
     using TestStack.White;
     using TestStack.White.UIItems;
     using TestStack.White.UIItems.Finders;
     using TestStack.White.UIItems.ListBoxItems;
     namespace ConsoleApplication1
     {
         public class Program
         {
             public static void Main(string[] args)
             {
                 var application = Application.Attach("MFCApplication1");
                 var window = application.GetWindow("MFCApplication11 - MFCApplication1");
                 //Edit Control
                 var propertyPane = window.Get<Panel>(SearchCriteria.ByAutomationId("150"));
                 var edit = propertyPane.Get<TextBox>(SearchCriteria.ByAutomationId("1"));
                 //Type this text into the edit control
                 edit.Text = "Hello World";
                 //List View
                 var output = window.Get<Panel>(SearchCriteria.ByAutomationId("149"));
                 var list = output.Get<ListBox>(SearchCriteria.ByAutomationId("2"));
                 //Output the count of how many rows exist
                 Console.Out.WriteLine(list.Items.Count);
                 //Select the second row
                 list.Items[1].Select();
             }
         }
     }
