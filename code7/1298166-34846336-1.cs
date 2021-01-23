	public void test() {
		List<S> DataItems = new List<S>();
		DataItems.Add(new S { A = 1, B = 2, C = 3 });
		DataItems.Add(new S { A = 12, B = 8, C = 7 });
		DataItems.Add(new S { A = 5, B = 1, C = 0 });
		DataItems.Add(new S { A = 7, B = 3, C = 2 });
		DataItems.Add(new S { A = 10, B = 6, C = 5 });
		DataItems.Add(new S { A = 6, B = 2, C = 1 });
		DataItems.Add(new S { A = 8, B = 4, C = 3 });
		DataItems.Add(new S { A = 6, B = 1, C = 5 });
		DataItems.Add(new S { A = 7, B = 2, C = 6 });
		DataItems.Add(new S { A = 8, B = 3, C = 7 });
		DataItems.Add(new S { A = 9, B = 4, C = 8 });
		DataItems.Add(new S { A = 11, B = 7, C = 6 });
		DataItems.Add(new S { A = 13, B = 9, C = 8 });
		DataItems.Add(new S { A = 11, B = 6, C = 10 });
		DataItems.Add(new S { A = 12, B = 7, C = 11 });
		DataItems.Add(new S { A = 13, B = 8, C = 12 });
		DataItems.Add(new S { A = 14, B = 9, C = 13 });
		int index = 1; //0-th element does not need to be checked
		while (index < DataItems.Count) {
			S currentS = DataItems[index];
            bool isRemoved = false;
			for (int i = 0; i < index; ++i) {//compare with the previous items
				if (currentS.IsSimilarTo(DataItems[i])) {
                    isRemoved = true;
					DataItems.Remove(currentS);
					break;
				}
			}
            index += isRemoved ? 0 : 1;
		}
	}
