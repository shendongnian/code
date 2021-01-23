    using System;
    using System.Collections.Generic;
    using Xceed.Wpf.AvalonDock.Layout;
    
    namespace Central.Services
    {
        public class DockinWindowChildObjectDictionary
        {
            private static Dictionary<string, LayoutAnchorable> _contentPane = new Dictionary<string, LayoutAnchorable>();
            private static readonly Lazy<DockinWindowChildObjectDictionary> _instance = 
                new Lazy<DockinWindowChildObjectDictionary>(()=> new DockinWindowChildObjectDictionary(), true);
            public static DockinWindowChildObjectDictionary Instance 
            { 
                get
                {
                    return _instance.Value;
                } 
            }
    
            /// <summary>
            /// Causes the constructor to be private allowing for proper use of the Singleton pattern.
            /// </summary>
            private DockinWindowChildObjectDictionary()
            {
                
            }
    
            /// <summary>
            /// Adds a Content Pane instance to the dictionary.
            /// </summary>
            /// <param name="title">The title given to the Pane during instantiation.</param>
            /// <param name="contentPane">The object instance.</param>
            public static void Add(string title, LayoutAnchorable contentPane)
            {
                _contentPane.Add(title, contentPane);
            }
    
            /// <summary>
            /// If a window needs to be removed from the dock this should be used 
            /// to also remove it from the dictionary.
            /// </summary>
            /// <param name="title">The title given to the Pane during instantiation.</param>
            public static void Remove(string title)
            {
                _contentPane.Remove(title);
            }
    
            /// <summary>
            /// This will return the instance of the content pane that holds the view.
            /// </summary>
            /// <param name="title">The title given to the Pane during instantiation.</param>
            /// <returns>The views Parent Instance.</returns>
            public static LayoutAnchorable GetInstance(string title)
            {
                return _contentPane[title];
            }
        }
    }
