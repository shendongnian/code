     var task = collection.InsertOneAsync(new person
           {
                Id = setid,  
                FirstName = name,
                LastName= lastname,
                Email = email,
                playlists = [ //Array of objects
                  {videos:[  //Array of objects
                    {
                       title:"1", description:""
                    },
                    {
                       title:"2", description:""
                    }
                ]}
              ]
           });
