    class QueryBehaviour: MonoBehaviour
    {
      bool queryFinished = false;
      WWW wwwQuery;
      IEnumerator Query()
      {
        wwwQuery = new WWW("url_to_query");
        yield return wwwQuery;
      
        queryFinished = true;
        //results or error should be here
      }
      Update()
      {
        if( queryFinished == false )
        {
          return;
        }
        else
        {
          //use wwwQuery here
        }
      }
    }
