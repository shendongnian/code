    public class MoviesModel
    {
         public List<Movie> Movies  {get;set;}
    }
    
        //get all movies and return to view
        public ActionResult AllMovies()
        {       
           MoviesModel model=new MoviesModel();
           model.Movies=  db.Movies.ToList();
            if (model.Movies== null || model.Movies.Count==0)
            {
                return HttpNotFound();
            }
        
            return View(model);
        }
    
    
    //html view
        @model MoviesModel
        @foreach(var movie in Model.Movies){
           <input id="Button1" type="button" value="button" name="movie.Id" onclick="ButtonClicked(movie.Id)"/>
           <div class="hidden" id='movie.Id'>
              <span>...movie info...</span>
           </div>
        }
    //javascript
    
    function ButtonClicked(id)
    {
       var element= Document.GetEllementById(id)
      //set css class visible 
    }
    
    
    //CSS
    .visible
    {
    display:block;
    }
    
    .hide
    {
    display:none;
    }
