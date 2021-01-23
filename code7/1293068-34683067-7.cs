    public void DeleteProduct(TTSF_Product product)
            {
                try
                {
                    productRepository.DeleteProduct(product);
                    LabelControlID.Text = "Success";
                }
                catch (Exception ex)
                {
                    //Include catch blocks for specific exceptions first,
                    //and handle or log the error as appropriate in each.
                    //Include a generic catch block like this one last.
                   LabelControlID.Text = "Failure"; 
                   throw ex;
                }
            } 
