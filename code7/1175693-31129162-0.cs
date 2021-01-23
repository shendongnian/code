    IEnumerator query (WWW web)
    {
       yield return web;
       while(!web.isDone)
       {
        //this will loop until your query is finished
       }
       if(web.Error == null)
       {
         Debug.Log("No errors to display");
       }
       else
       {
         Debug.Log("Errors to display");
       }
    }
