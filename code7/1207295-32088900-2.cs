	public ref class ArrayExtensions abstract sealed {
		public:
			generic<typename T> static array<array<T>^> ^ToJaggedArray(array<T, 2> ^input)
			{
				if (input == nullptr)
					return nullptr;
				int nRow = input->GetLength(0);
				int nCol = input->GetLength(1);
				array<array<T>^> ^output = gcnew array<array<T>^>(nRow);
				for (int iRow = 0; iRow < nRow; iRow++)
				{
					output[iRow] = gcnew array<T>(nCol);
					for (int iCol = 0; iCol < nCol; iCol++)
						output[iRow][iCol] = input[iRow, iCol];
				}
				return output;
			}
			generic<typename T> static array<T, 2> ^To2DArray(array<array<T> ^>^input)
			{
				if (input == nullptr)
					return nullptr;
				int nRow = input->Length;
				int nCol = 0;
				for (int iRow = 0; iRow < nRow; iRow++)
					if (input[iRow] != nullptr)
						nCol = Math::Max(nCol, input[iRow]->Length);
				array<T, 2> ^ output = gcnew array<T, 2>(nRow, nCol);
				for (int iRow = 0; iRow < nRow; iRow++)
					if (input[iRow] != nullptr)
						for (int iCol = 0; iCol < input[iRow]->Length; iCol++)
							output[iRow, iCol] = input[iRow][iCol];
				return output;
			}
	};
