     int DesiredLinesCount = 100000 ;
     List<string> Lines=new List<string>() ;
     object[] UserObjects = new object[] { Lines } ; 
     SxProgress.Execute("Building lines",DesiredLinesCount,true,false,
                        BuildLines_ExecInThread,UserObjects)) ;
  
     private bool BuildLines_ExecInThread(int ItemIndex,object[] UserObjects)
    {
      // some sleep to slow down the process (demonstration purpose only)
      // if (ItemIndex % 10 ==0) System.Threading.Thread.Sleep(1) ; 
      List<string> Lines= (List<String>)UserObjects[0] ;
      Lines.Add("Hello world") ; 
      return true ; 
    }
