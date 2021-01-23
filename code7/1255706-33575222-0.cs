    public PlanningGwWrapperCell(IntPtr handle)
            : base(handle)
        {
            ...
            ContentView.AddSubview(new UILayoutHost(_header));
            ContentView.AddSubview(_playersTable);
            InitializeBindings();
            _playersTable.ReloadData();
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            _playersTable.Frame = new CGRect(0, Dimens.TableRowHeight, ContentView.Bounds.Width, Dimens.TableRowHeight);
            _header.LayoutParameters = new LayoutParameters(ContentView.Bounds.Width, Dimens.TableRowHeight);
        }
