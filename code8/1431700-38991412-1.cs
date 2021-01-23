    if (Values.Count != 0){   
        Dictionary<string, string> dictionary =
        	    new Dictionary<string, string>();
        char key = 'a';
        for (i = 0; i < Values.Count; i++){
        	dictionary.Add(key, Values[i]);
            key = (key == 'z'? 'a': (char)(input + 1));
        }
    }
