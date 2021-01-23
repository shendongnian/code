	private void SetTotal(int value)
	{
		stack.Push(total);
		total = value;
	}
	public void Add(int value) { SetTotal(total + value); }
	public void Subtract(int value) { SetTotal(total - value); }
	public void Multiply(int value) { SetTotal(total * value); }
	public void Undo() { total = stack.Count > 0 ? stack.Pop() : 0; }
