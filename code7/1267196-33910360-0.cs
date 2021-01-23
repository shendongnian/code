    static IEnumerable<int> RemoveFirstSubset(int[] super, int[] sub)
    {
        //omitted code to check parameters
                    
        var index = 0;
        var found = false;
        while (index < super.Length)
        {
            if (!found && super.Skip(index).Take(sub.Length).SequenceEqual(sub))
            {
                found = true;
                index += sub.Length;
            }
            else
            {
                yield return super[index];
                index++;
            }
        }
    }
