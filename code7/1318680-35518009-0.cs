        private static FieldInfo _dataGridViewState1FieldInfo = null;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_dataGridViewState1FieldInfo == null)
            {
                var type = typeof (DataGridView);
                var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                                | BindingFlags.Static;
                _dataGridViewState1FieldInfo = type.GetField("dataGridViewState1", bindFlags);
            }
            if (_dataGridViewState1FieldInfo != null)
            {
                BitVector32 bits = (BitVector32) _dataGridViewState1FieldInfo.GetValue(this);
                if (bits[0x00000800])
                {
                    bits[0x00000800] = false;
                    _dataGridViewState1FieldInfo.SetValue(this, bits);
                }
            }
            base.OnMouseDown(e);
        }
