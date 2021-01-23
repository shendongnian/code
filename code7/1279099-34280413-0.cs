    try
     { 
      Directory.Copy(@"c:/Users/Public/TestFolder", @"c:/Users/Public/TestFolder1",true);// will take a copy of the directory TestFolder1
      Directory.Move(@"c:/Users/Public/TestCase", @"c:/Users/Public/TestCase1");//will move TestFolder to TestFolder2
     }
    catch{//handle exception here}
