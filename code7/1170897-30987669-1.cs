    public class UoW {
  
       public UoW( DbContext ctx ) {
          this._ctx = ctx;
       }
       private Repository1 _repo1;
       public Repository1 Repo1
       {
          get
          {
              if ( _repo1 == null )
                  _repo1 = new Repository1( this._ctx );
              return _repo1;
          }
         
          ...
