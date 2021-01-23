    using System.Collections;
    using System.Linq;
    using System.Windows.Forms;
    public class ExPropertyGrid : PropertyGrid
    {
        protected override bool ProcessTabKey(bool forward)
        {
            var grid = this.Controls[2];
            var field = grid.GetType().GetField("allGridEntries",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            var entries = (field.GetValue(grid) as IEnumerable).Cast<GridItem>().ToList();
            var index = entries.IndexOf(this.SelectedGridItem);
            if (forward && index < entries.Count - 1)
            {
                var next = entries[index + 1];
                next.Select();
                return true;
            }
            return base.ProcessTabKey(forward);
        }
    }
