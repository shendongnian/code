    public class WeightedRegex
    {
           public int Weight {get;set;}
           public Regex Regex {get;set;}
    }
    
    //in your method
    //assuming you have a List of WeightedRegex called regexes 
    if (name_exp.Match(input_string).Success==true);
    { 
           weight =  regexes.First(a=>a.IsMatch(input_string)).Weight;
    }  
   
