    for (int i = 0; i < MyGameObjects.Count; ++i) {
        if (MyGameObjects[i].GetType() == typeof(DrawableGameObject)) {
            ((DrawableGameObject)MyGameObjects[i]).Animation;
        }
    }
