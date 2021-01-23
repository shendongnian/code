       if(!hashesString.Add(s))
       { // Count collisions only for new strings
         testedCollisions++ ;
         if (!hashes.Add(Get64BitHash( s ))) collisions++;
       }
     }
     Console.WriteLine("Collision Percentage after " + testedCollisions + " random strings: " + ((double)collisions * 100 / testedCollisions));
