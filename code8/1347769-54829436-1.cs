    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    
    using Microsoft.VisualStudio.Imaging.Interop;
    namespace Sago.TemQWindow.Classes
    {
        /// <summary>
        /// Represents a simple data item to display easy an item inside a view
        /// </summary>
        public class MenuNode
        {
            ...
            /// <summary>
            /// Gets or sets the display image
            /// </summary>
            public ImageMoniker Image { get; set; }
            ...
        }
    }
