    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace GroupedCheckBoxTest
    {
        public class GroupedCheckBox : CheckBox
        {
            /// <summary>
            /// All the members of the current group
            /// </summary>
            private IEnumerable<GroupedCheckBox> currentGroup;
    
            /// <summary>
            /// Gets or sets the name that specifies which GroupedCheckBox controls are mutually exclusive.
            /// </summary>
            public string GroupName { get; set; }
    
            /// <summary>
            /// Indicates when the checked state of the GroupedCheckBox changes
            /// </summary>
            public event EventHandler CheckChanged;
    
            public GroupedCheckBox()
            {
                // Add only the current checkbox to the group
                // (for now, but potentially always)
                currentGroup = this.SingleItemAsEnumerable();
    
                // Attach empty delegate so we don't have to keep checking for null
                this.CheckChanged += delegate { };
    
                // Aggregate all checked changed events
                this.Checked += GroupedCheckBox_Checked;
    
                // Associate all GroupedCheckBoxs once they are loaded
                this.Loaded += GroupedCheckBox_Loaded;
            }
    
            // False when any one of the group checked
            void GroupedCheckBox_Checked(object sender, RoutedEventArgs e)
            {
                // Uncheck everyone else in the group
                foreach (GroupedCheckBox otherCB in currentGroup.Except(this.SingleItemAsEnumerable()))
                {
                    // Uncheck the other checkbox
                    otherCB.IsChecked = false;
                }
    
                this.CheckChanged(this, e);
            }
    
            void GroupedCheckBox_Loaded(object sender, RoutedEventArgs e)
            {
                // If this GroupedCheckBox isn't even part of a group
                if (string.IsNullOrEmpty(this.GroupName))
                {
                    // We don't need to do anything special
                    return;
                }
    
                // The highest parent node we can get to
                DependencyObject parentNode = this;
    
                // Walk the control tree until we get to the top
                while (VisualTreeHelper.GetParent(parentNode) != null)
                {
                    // Get the parent of the current node
                    parentNode = VisualTreeHelper.GetParent(parentNode);
                }
    
                // Get all GroupedCheckBox's with the same GroupName as this one
                currentGroup = parentNode.GetControlsOfType<GroupedCheckBox>().Where(cb => this.GroupName == cb.GroupName);
            }
        }
    
        internal static class GroupedCheckBoxHelperExtensions
        {
            public static IEnumerable<T> GetControlsOfType<T>(this DependencyObject depObj) where T : DependencyObject
            {
                if (depObj != null)
                {
                    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                    {
                        DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                        if (child != null && child is T)
                        {
                            yield return (T)child;
                        }
    
                        foreach (T childOfChild in GetControlsOfType<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
    
            // usage: someObject.SingleItemAsEnumerable();
            public static IEnumerable<T> SingleItemAsEnumerable<T>(this T item)
            {
                yield return item;
            }
        }
    }
