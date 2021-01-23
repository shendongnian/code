        public static void HideImageMargins([NotNull] this MenuStrip menuStrip)
        {
            HideImageMargins(menuStrip.Items.OfType<ToolStripMenuItem>().ToList());
        }
        private static void HideImageMargins([NotNull] this List<ToolStripMenuItem> toolStripMenuItems)
        {
            toolStripMenuItems.ForEach(item =>
                          {
                              if (!(item.DropDown is ToolStripDropDownMenu dropdown))
                              {
                                  return;
                              }
                              dropdown.ShowImageMargin = false;
                              HideImageMargins(item.DropDownItems.OfType<ToolStripMenuItem>().ToList());
                          });
        }
