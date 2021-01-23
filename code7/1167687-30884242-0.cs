    for (int i = 0; i < listview.Items.Count; i++) {
                for (int i_ = 0; i_ < listview.Items.Count; i++) {
                    if (listview.Items[i].Tag == listview.Items[i_].Tag) {
                        listview.Items[i].Remove();
                    }
                }
            }
