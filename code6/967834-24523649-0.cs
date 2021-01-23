    public static class ListExtension {
         public static bool IsLastPhotoNotNull(this List<Album> albums){
              var album = albums.Last();
              if (album != null){
                   return album.Photos != null && album.Photos.Description != null;
              }
              return false;
         }
    }
