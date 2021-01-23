    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    { 
        class UploadedSong { 
            public string Author{get;set;}
            public string Name{get;set;}
            public float Length{get;set;}
            public string Path{get;set;}
            public byte[] SizeInBytes{get;set;}
        }
        
        public void UpdateSongDetails(IEnumerable<UploadedSong> uploadedSongs, IEnumerable<UploadedSong> songDetails) { 
            // Note that this might blow up if you have duplicate song names
            // You gave very little to work with so my preconditions are weak
            
            var lookupDetails = songDetails.ToDictionary(song => song.Name, song => song);
            
            foreach(var uploadedSong in uploadedSongs) {
                var key = uploadedSong.Name;
                if(lookupDetails.ContainsKey(key)) {
                    var details = lookupDetails[key];
                    uploadedSong.Author = details.Author; 
                    // ... more details here
                }
            }
        }
        
        static void Main()
        {
            // I am assuming that song details is something you populate from some reliable source
            // but for simpilicity I will just declare it.
            var songDetails = new List<UploadedSong>(); 
            var uploadedSongs = (IEnumerable<UploadedSong>)(Session["UserSongs"]);
            UpdateSongDetails(uploadedSongs, songDetails);
        }
    }
