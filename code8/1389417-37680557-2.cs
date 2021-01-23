    // Loop through your index values in your string
    for(int i = 0; i < input.Length; i++)
    {
          // If you removed a certain character, would it form a palindrome?
          if(IsPalindrome(input.Remove(i,1)){
               // If so, return the index
               return i;
          }
    }
 
