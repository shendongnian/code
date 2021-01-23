    public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
    {
      ViewSwitcher itemView = new ViewSwitcher(parent.Context);
      itemView.addView(LayoutInflater.From(parent.Context).Inflate (Resource.Layout.ItemCardViewUploading, parent, false), 0, null);
      itemView.addView(LayoutInflater.From (parent.Context).Inflate (Resource.Layout.ItemCardView, parent, false), 0, null);
      return new ItemViewHolder(itemView, OnClick, OnItemMenuClick);
    }
    
    // you may want to change parameter to fit the way you identify your file
    public void onUploadCompleted(long itemId)
    {
      ItemViewHolder vh = (ItemViewHolder) findViewHolderForItemId(itemId);
      ((ViewSwitcher) vh.itemView).showNext();
    }
