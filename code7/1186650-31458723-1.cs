    /// <summary>
    /// Provide utilities methods related to <see cref="Control"/> objects
    /// </summary>
    public static class ControlUtilities
    {
        /// <summary>
        /// Find the first ancestor of the selected control in the control tree
        /// </summary>
        /// <typeparam name="TControl">Type of the ancestor to look for</typeparam>
        /// <param name="control">The control to look for its ancestors</param>
        /// <returns>The first ancestor of the specified type, or null if no ancestor is found.</returns>
        public static TControl FindAncestor<TControl>(this Control control) where TControl : Control
        {
            if (control == null) throw new ArgumentNullException("control");
    
            Control parent = control;
            do
            {
                parent = parent.Parent;
                var candidate = parent as TControl;
                if (candidate != null)
                {
                    return candidate;
                }
            } while (parent != null);
            return null;
        }
    
        /// <summary>
        /// Finds all descendants of a certain type of the specified control.
        /// </summary>
        /// <typeparam name="TControl">The type of descendant controls to look for.</typeparam>
        /// <param name="parent">The parent control where to look into.</param>
        /// <returns>All corresponding descendants</returns>
        public static IEnumerable<TControl> FindDescendants<TControl>(this Control parent) where TControl : Control
        {
            if (parent == null) throw new ArgumentNullException("control");
    
            if (parent.HasControls())
            {
                foreach (Control childControl in parent.Controls)
                {
                    var candidate = childControl as TControl;
                    if (candidate != null) yield return candidate;
    
                    foreach (var nextLevel in FindDescendants<TControl>(childControl))
                    {
                        yield return nextLevel;
                    }
                }
            }
        }
    }
