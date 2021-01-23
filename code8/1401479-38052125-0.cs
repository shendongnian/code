      AlertDialog.Builder builder = new AlertDialog.Builder(this);
                     builder.SetTitle("Preview");  
     var temp= new ImageView(this);   
    temp.SetImageBitmap(App.bm);                   
                     builder.SetView(temp);
                     builder.SetCancelable(false);
                     builder.SetPositiveButton("Cancel", (senderAlert, args) => { });
                     builder.SetNegativeButton("Delete?", (senderAlert, args) =>
                     {
    
                         Java.Lang.Object toRemove = myFileListAdapter.GetItem(e.Position);
                         myFileListAdapter.Remove(toRemove);
                         myFileListAdapter.NotifyDataSetChanged();
                         setListViewHeightBasedOnChildren(listViewFiles);
    
                     });
    
                     builder.Show();
                    };
