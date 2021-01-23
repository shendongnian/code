     private void NodeBarcode_1_Execute(EventArgs e) {
                try {
                    IProduct NodeObj = ObjectFactory<IProduct>.Create("Node");
                    NodeObj.Barcode = NodeBarcode_1_txt;
                    NodeObj.Validation();
                    labelAppObj.AddProduct(NodeObj);
                    NodeBarcode_1_GetFocusNow = false; // <--- Here
                    NodeBarcode_2_GetFocusNow = true;
    
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    NodeBarcode_1_txt = string.Empty;
                }
            }
    
            private void NodeBarcode_2_Execute(EventArgs e) {
                try {
                    IProduct NodeObj = ObjectFactory<IProduct>.Create("Node");
                    NodeObj.Barcode = NodeBarcode_2_txt;
                    NodeObj.Validation();
                    labelAppObj.AddProduct(NodeObj);
                    NodeBarcode_1_GetFocusNow = true;
                    NodeBarcode_2_GetFocusNow = false; // <--- Here
    
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    NodeBarcode_2_txt = string.Empty;
                }
            }
