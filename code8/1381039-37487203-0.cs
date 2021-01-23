            // Metodo che inizializza il ViewHolder
        public override ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.VarianteCardView, parent, false);
            ViewHolderCard vh = new ViewHolderCard(itemView, OnClick);
            // Gestisco il click del pulsante opzioni di ciascuna CardView
            vh.imgCardOptions.Click += (o, e) =>
            {
                Toast.MakeText(context, "ciao " + vh.AdapterPosition.ToString(), ToastLength.Short).Show();
                PopupMenu popup = new PopupMenu(context, vh.imgCardOptions);
                popup.Inflate(Resource.Menu.CardMenu);
                popup.MenuItemClick += (s, args) =>
                {
                    switch (args.Item.ItemId)
                    {
                        case Resource.Id.delete:
                            Toast.MakeText(context, "delete " + vh.AdapterPosition.ToString(), ToastLength.Short).Show();
                            break;
                        case Resource.Id.edit:
                            Toast.MakeText(context, "edit " + vh.AdapterPosition.ToString(), ToastLength.Short).Show();
                            break;
                    }
                };
                popup.Show();
            };
            return vh;
        }
            // Metodo che specifica il contenuto del ViewHolder (effettua il bind dei dati)
        public override void OnBindViewHolder(ViewHolder holder, int position)
        {
           
            ViewHolderCard vh = holder as ViewHolderCard;
            vh.txtVarianteId.Text = varianti[position].ID.ToString();
            vh.txtVarianteModello.Text = varianti[position].codiceModello;
            vh.txtVarianteBrand.Text = varianti[position].brand;
            
            if (varianti[position].fotoUrl != null)
            {
                BitmapFactory.Options options = new BitmapFactory.Options();
                options.InSampleSize = 1;
                Bitmap myBitmap = BitmapFactory.DecodeFile(Utils.urlImageToThumb(varianti[position].fotoUrl), options);
                vh.imgVariantePhoto.SetImageBitmap(myBitmap);
                //vh.imgVariantePhoto.SetOnTouchListener(new TouchListenerHelper(vh, mDragStartListener)); // Rimosso perchè altrimenti il drag avviene senza long click (basta fare lo swipe sull'immagine ad avviene il drag)
                myBitmap.Dispose();
            }
        }
