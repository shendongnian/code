    public static class ListExtension {
         public static bool IsLastPhotoNotNull(this List<Album> albums){
              var album = albums.LastOrDefault();
              return album != null && album.Photos != null && album.Photos.Description != null;
         }
    }
