    using System.Linq;
    ...
    var checkboxIndices = { 0, 2, 17 };
    x += checkboxIndices.Count(index =>
             checkedListBox1.GetItemCheckState(index) == CheckState.Checked);
