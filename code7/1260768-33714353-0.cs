		this._gattCallback.CharacteristicValueUpdated += (object sender, CharacteristicReadEventArgs e) => {
				// it may be other characteristics, so we need to test
				if(e.Characteristic.ID == this.ID) {
					// update our underlying characteristic (this one will have a value)
					//TODO: is this necessary? probably the underlying reference is the same.
					//this._nativeCharacteristic = e.Characteristic;
					this.ValueUpdated (this, e);
				}
			};
	
