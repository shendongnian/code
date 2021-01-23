    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    public class ExPropertyGrid : PropertyGrid
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            var grid = this.Controls[2];
            grid.MouseClick += grid_MouseClick;
        }
        void grid_MouseClick(object sender, MouseEventArgs e)
        {
            var grid = this.Controls[2];
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var invalidPoint = new Point(-2147483648, -2147483648);
            var FindPosition = grid.GetType().GetMethod("FindPosition", flags);
            var p = (Point)FindPosition.Invoke(grid, new object[] { e.X, e.Y });
            GridItem entry = null;
            if (p != invalidPoint)
            {
                var GetGridEntryFromRow = grid.GetType()
                                              .GetMethod("GetGridEntryFromRow", flags);
                entry = (GridItem)GetGridEntryFromRow.Invoke(grid, new object[] { p.Y });
            }
            if (entry != null && entry.Value != null)
            {
                object parent;
                if (entry.Parent != null && entry.Parent.Value != null)
                    parent = entry.Parent.Value;
                else
                    parent = this.SelectedObject;
                if (entry.Value != null && entry.Value is bool)
                {
                    entry.PropertyDescriptor.SetValue(parent,!(bool)entry.Value);
                    this.Refresh();
                }
            }
        }
    }
