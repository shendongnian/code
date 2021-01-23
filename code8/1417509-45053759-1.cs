    List<object> nestedObjects = new List<object> {new Rules()};
    
    			ISpecification<Blog> blogSpec = new BlogSpec(blogId, nestedObjects); 
    
    			var challenge = await this._blogRepository.FindOne(blogSpec);
