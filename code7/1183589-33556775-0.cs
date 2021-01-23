    // The file first needs to be uploaded to Parse before it can be saved to the object in the database
     ParseFile _playerFile;
 
     public void CreatePlayer()
     {
         StartCoroutine (UploadPlayerFile ((response) => {
             if(response == 1)
                 StartCoroutine(CreateProjectAsync());                        
             else
                 Debug.LogError("The file could not be uploaded");
         }));
     }        
 
     IEnumerator UploadPlayerFile(Action <int> callback)
     {
         var fileBytes = System.IO.File.ReadAllBytes (@"C:\myfile.jpg");
         _playerFile = new ParseFile ("file.jpg",  fileBytes, "image/jpeg");
 
         var saveTask = _playerFile.SaveAsync ();
 
         while (!saveTask.IsCompleted)
             yield return null;        
 
         if (saveTask.IsFaulted) {
             Debug.LogError ("An error occurred while uploading the player file : " + saveTask.Exception.Message);
             callback (-1);
         } else {            
             callback (1);
         }    
     }
 
     IEnumerator CreateProjectAsync()
     {        
         ParseObject player = new ParseObject ("Player");
         player ["Number"] = 111;
         player ["Files"] = _playerFile;
 
         var saveTask = player.SaveAsync ();
 
         while (!saveTask.IsCompleted)
             yield return null;        
 
         if (saveTask.IsFaulted) {
             Debug.LogError ("An error occurred while creating the player object : " + saveTask.Exception.Message);
 
         } else {    
             Debug.Log ("Player created successfully");
         }    
     }
