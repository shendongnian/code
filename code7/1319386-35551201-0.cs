        protected override void OnElementChanged(ElementChangedEventArgs<SoundsPicker> e)
        {
            if (e.NewElement != null)
            {
                if (base.Control == null)
                {
                    EditText editText = new EditText(Context)
                    {
                        Focusable = false,
                        Clickable = true,
                        Tag = this
                    };
                    var padding = (int)Context.ToPixels(10);
                    // that show image on right side
                    editText.SetCompoundDrawablesWithIntrinsicBounds(0, 0, Resource.Drawable.arrow_down, 0);
                    editText.CompoundDrawablePadding = padding;
                    editText.SetOnClickListener(MyPickerPickerListener.Instance);
                    editText.SetBackgroundDrawable(null);
                    SetNativeControl(editText);
                }
            }
            base.OnElementChanged(e);
        }
