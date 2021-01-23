            string fn = System.IO.Path.GetFileName(fnwithExt);
            int indexOf = fn.LastIndexOf('_');
            string part1 = fn.Substring(0, indexOf-1);
            string part2 = fn.Substring(indexOf+1);
            string part3 = System.IO.Path.GetExtension(fnwithExt);
            string original = System.IO.Path.ChangeExtension(part1 + "_"+ part2, part3);
  
