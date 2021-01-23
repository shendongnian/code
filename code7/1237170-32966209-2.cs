      class Yaku
       {
           public Yaku(List<int> indices, int han)
           {
               Indices = indices;
               HanValue = han;
           }
           public List<int> Indices;
           public int HanValue;
           public int ComputeValue(CheckedListBox checkedListBox)
           {
                return HanValue * Indices.Count(index =>
                    checkedListBox.GetItemCheckState(index) == CheckState.Checked);
           }
       }
    
       ...
       var yakus = [
           new Yaku({0, 2, 17 }, 1),
           new Yaku({1}, 2)
           ...
       ];
       var totalYakuValue = yakus.Aggregate(yaku => yaku.ComputeValue());
   
