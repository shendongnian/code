    // split the string into an array of int ids
    var idsModulos = keyvaluepairModulos.Value.ToString().Split(',');
    // project each id into a modulo instance
    var listOfModulos = idsModulos
        .Select(id => unitOfWork.ModuloRepository.GetById(Convert.ToInt32(id)))
        .ToList();
    // it's simpler to use Tuple.Create instead of the Tuple constructor
    // because you don't need to specify generic arguments in that case (they are infered)
    var tuple = Tuple.Create(name, listOfModulos);
