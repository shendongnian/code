    List<string> enumColors = Enum.GetNames(typeof(MyColours)).ToList();
    foreach(string s in enumColors){
           if( enumColors.exists( c => c == s ) )
                return true;
           else 
                return false;
    }
