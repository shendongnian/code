        void _orgStructEntitesCheckedComboBoxEdit_Popup(object sender, EventArgs e)
        {
            var popup = (IPopupControl)sender;
            var control = popup.PopupWindow.Controls.OfType<PopupContainerControl>().First().Controls.OfType<CheckedListBoxControl>().First();
            control.ItemCheck += control_ItemCheck;
        }
        void control_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var checkedListBoxControl = (CheckedListBoxControl)sender;
            var checkedItems = checkedListBoxControl.Items.Cast<CheckedListBoxItem>()
                                .Where(x => x.CheckState == CheckState.Checked)
                                .Select(x => x.Value)
                                .ToArray();
        }
