    // defined at class level/scope outside method
    private List<block> blocks;
    ...
    private int SumAll(int id) {
          var initialBlock = blocks.FirstOrDefault(b => b.id == id);
          int value = initialBlock.Value;
          var childBlocks = blocks.Where(b => b.parentId = id).ToList();
          foreach (var childBlock in childBlocks) {
                value += SumAll(childBlock.id);
          }
          return value;
    }
