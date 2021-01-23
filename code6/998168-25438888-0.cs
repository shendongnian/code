    @using Orchard.ContentManagement
    @using Orchard.MediaLibrary.Models
    @using Orchard.Utility.Extensions
    @model dynamic
    
        @{
            ContentItem contentItem = Model.ContentItem;
            var media = contentItem.As<MediaPart>();
            var image = contentItem.As<ImagePart>();
            var width = ViewBag.ResizedThumbnailWidth ?? 200;
        }
    
        <div>
            <img src="@Display.ResizeMediaUrl(
                           Width: width, 
                           Mode: "max", 
                           Alignment: "middlecenter", 
                           Path: media.MediaUrl)" />
        </div>
