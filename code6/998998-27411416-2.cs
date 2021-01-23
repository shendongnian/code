    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Phone.Controls;
    
    namespace MobileWin8Phone.ImageItem
    {
        class OnlineMediaThumbnailedImage : IThumbnailedImage
        {
            private Stream _stream;
            private string _imageUrl;
    
            /// <summary>
            /// This class implements the IThumbnailedImage interface so that it can be
            /// consumed by the MediaViewer control.  Obtain the Stream of an image and
            /// pass it in so that the MediaViewer control can call GetImage() when needed.
            /// </summary>
            /// <param name="theImageStream"></param>
            /// <param name="imageUrl"></param>
            public OnlineMediaThumbnailedImage(Stream theImageStream, string imageUrl = "")
            {
                _stream = theImageStream;
                _imageUrl = imageUrl;
            }
    
            /// <summary>
            /// Returns a Stream representing the thumbnail image.
            /// </summary>
            /// <returns>Stream of the thumbnail image.</returns>
            public Stream GetThumbnailImage()
            {
                return this._stream;
            }
    
            /// <summary>
            /// Returns a Stream representing the full resolution image.
            /// </summary>
            /// <returns>Stream of the full resolution image.</returns>
            public Stream GetImage()
            {
                return this._stream;
            }
    
            /// <summary>
            /// Represents the time the photo was taken, useful for sorting photos.
            /// </summary>
            public System.DateTime DateTaken
            {
                get
                {
                    return System.DateTime.Today;
                }
            }
        }
    }
