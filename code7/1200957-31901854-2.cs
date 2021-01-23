    private Stack<Category> GetChildsAndRoot(Category category)
    {
                var stack = new Stack<Category>();
                var queue = new Queue<Category>();
                stack.Push(category);
                queue.Enqueue(category);
                while (queue.Any())
                {
                    var currCategory = queue.Dequeue();
                    foreach (var child in currCategory.Childs)
                    {
                        queue.Enqueue(child);
                        stack.Push(child);
                    }
                }
     
                return stack;
    }
    var category = _categoryRepository.GetByID(id);
     
    var nodes = GetChildsAndRoot(category);
    while (nodes.Any())
    {
            _categoryRepository.Delete(nodes.Pop());
    }
                     
    _unitOfWork.SaveChanges();
