     function gv_CustomButton_Click(s, e) {
                switch (e.buttonID) {
                    case "cmdPrint":
                        if (confirm("Print?")) {
                            s.GetRowValues(e.visibleIndex, 'ID', PrintCommand);
                        }
                }
            }
    
            function PrintCommand(values) {
                var ID = values; //this will give u actual ID.
                //put your actions here
            }
