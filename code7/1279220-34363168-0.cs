    static IEnumerable<ElementDto> MapElements(Element[] elements)
    {
        var elementToDtoMap = new Dictionary<Element, ElementDto>();
            
        foreach (var element in elements)
        {
            MapElement(element, null, elementToDtoMap);
        }
        return elementToDtoMap.Select(_ => _.Value);
    }
    static void MapElement(Element element, ItemDto parentItem, Dictionary<Element, ElementDto> elementToDtoMap)
    {
        ElementDto elementDto = null;
        if (elementToDtoMap.TryGetValue(element, out elementDto))
                return;
            
        elementDto = Mapper.Map<ElementDto>(element);
        elementToDtoMap.Add(element, elementDto);
        if (parentItem != null)
        {
            parentItem.Element = elementDto;
        }
            
        if (element.Item != null)
        {
            MapElement(element.Item.Element, elementDto.Item, elementToDtoMap);
        }
    }
