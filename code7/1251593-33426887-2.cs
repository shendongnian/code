    public override void Update(GameTime gameTime)
    {
        List<GameObject> list = Instance.AllOf(typeof(Dummy));
    
        for(int i = 0; i < list.Count; i++)
        {
            list[i].Update(gameTime);
            list[i].foo += bar;
    
            int fooBar = 2;
            someObject.someMemberFunction(fooBar);
        }
    }
