    EditText QtyChange = FindViewById<EditText>(Resource.Id.txt_qty_change);
    this.QtyChange.TextChanged += QtyChange_TextChanged;
    private async void QtyChange_TextChanged(object sender, TextChangedEventArgs e)
                {
                    await System.Threading.Tasks.Task.Delay(600);
                    int newQuant;
                    if (Int32.TryParse(e.Text.ToString(), out newQuant))
                    {
                        // Update text here:
                        something.Text = newQuant
                        adapter.NotifyItemChanged(AdapterPosition);
                    }
                }
