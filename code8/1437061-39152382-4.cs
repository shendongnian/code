    private class ViewHolder : Java.Lang.Object
    		{
    			//public EventHandler<>
    			public ImageView Image { get; set; }
    			public Button Qtd { get; set; }
    			public TextView Stock { get; set; }
    			public TextView Name { get; set; }
    			public TextView Creditos { get; set; }
    			public Button Comprar { get; set; }
    
    			//New Event Handler
    			public EventHandler<ImageClickedEventArgs> ImageClicked;
    
    			public ViewHolder(View view)
    			{
    				Image = view.FindViewById<ImageView>(Resource.Id.singleRowStore);
    				Qtd = view.FindViewById<Button>(Resource.Id.buttonComprar);
    				Stock = view.FindViewById<TextView>(Resource.Id.stockStore);
    				Name = view.FindViewById<TextView>(Resource.Id.nomeStore);
    				Creditos = view.FindViewById<TextView>(Resource.Id.creditosStore);
    				Comprar = view.FindViewById<Button>(Resource.Id.comprarStore);
    
    				Image.Click += Image_Click;
    			}
    
    			void Image_Click(object sender, EventArgs e)
    			{
    				ImageClicked?.Invoke(sender, new ImageClickedEventArgs(this));
    			}
    
    			public class ImageClickedEventArgs : EventArgs
    			{
    				public ViewHolder ViewHolder { get; private set; }
    
    				public ImageClickedEventArgs(ViewHolder viewHolder) : base()
    				{
    					ViewHolder = viewHolder;
    				}
    			}
    		}
