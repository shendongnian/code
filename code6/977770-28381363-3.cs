    using System;
    using System.ComponentModel.Composition;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    
    namespace Piranha.Extend.Regions
    {
        /// <summary>
        /// Simple Tab region.
        /// </summary>
        [Export(typeof(IExtension))]
        [ExportMetadata("InternalId", "TabRegion")]
        [ExportMetadata("Name", "TabRegionName")]
        [ExportMetadata("ResourceType", typeof(Resources.Extensions))]
        [ExportMetadata("Type", ExtensionType.Region)]
        [Serializable]
        public class TabRegion :  Extension
        {
            #region Properties
            /// <summary>
            /// Gets/sets the Tab title.
            /// </summary>
            [Display(ResourceType = typeof(Piranha.Resources.Extensions), Name = "TabRegionTitle")]
            public string Title { get; set; }
    
            /// <summary>
            /// Gets/sets the Tab body.
            /// </summary>
            [Display(ResourceType = typeof(Piranha.Resources.Extensions), Name = "TabRegionBody")]
            public string Body { get; set; }
            #endregion
        }
    }
