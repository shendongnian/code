     private static object locker = new object();
     public bool Generate_PDF(decimal wo_id)
     {
          lock(locker){
            if (Fill_WO_Report_Table(wo_id) == false)	// this function has queries
                return false;
                ........
                ........
                return true;
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "WO Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          }//END LOCK
        } 
