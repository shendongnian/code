    void OnMouseDown()
    {
        if (!listOfCubes.Any(c => c.material.color == Color.Red))
        {
            render.material.color = colors[Random.Range(0, colors.Lenght)];
        }
    }
