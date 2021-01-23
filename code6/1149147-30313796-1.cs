	generic<class Data>
	public ref class BinaryTreeWrapperClass
	{
	public:
		BinaryTreeWrapperClass(){ tree = new BinaryTree(); }
		~BinaryTreeWrapperClass(){ this->!BinaryTreeWrapperClass(); }
		!BinaryTreeWrapperClass(){ delete tree; }
	private:
		BinaryTree* tree;
	};
