        void _orgStructEntitesCheckedComboBoxEdit_Popup(object sender, EventArgs e)
        {
            var popup = (IPopupControl)sender;
            var control = popup.PopupWindow.Controls.OfType<PopupContainerControl>().First().Controls.OfType<CheckedListBoxControl>().First();
            control.ItemCheck += control_ItemCheck;
        }
        void control_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            var checkedListBoxControl = (CheckedListBoxControl)sender;
            var current = checkedListBoxControl.Items[e.Index];
        }
