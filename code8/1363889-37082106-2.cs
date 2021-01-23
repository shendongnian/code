    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                var structure = new Structure();
                var protein = new Protein(0.5F, "FKABAKB");
                protien.ApplyToStructure(structure);
            }
        }
        public class Protein
        {
            private readonly ReadOnlyCollection<Amino> _aminos;
            public Protein(float value, string aminos)
            {
                Value = value;
                _aminos = aminos
                    .Select(Amino.FromAminoCharater)
                    .ToList()
                    .AsReadOnly();
            }
            public float Value { get; }
            public void ApplyToStructure(Structure structure)
            {
                foreach (var amino in _aminos)
                {
                    amino.ApplyToStructure(structure, this);
                }
            }
        }
        public class Structure
        {
            public float Size { get; set; }
            public float Id { get; set; }
        }
        public abstract class Amino
        {
            private static readonly Dictionary<char, Amino> AllProteinProperties = typeof(Amino)
                .GetNestedTypes(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(nestedType => typeof(Amino).IsAssignableFrom(nestedType))
                .Select(nestedType => (Amino)Activator.CreateInstance(nestedType))
                .ToDictionary(proteinProperty => proteinProperty.AminoCharacter);
            public static Amino FromAminoCharater(char aminoCharacter)
            {
                Amino amino;
                if (!AllProteinProperties.TryGetValue(aminoCharacter, out amino))
                {
                    throw new ArgumentException("Invalid amino");
                }
                return amino;
            }
            public abstract char AminoCharacter { get; }
            public abstract void ApplyToStructure(Structure structure, Protein protein);
            private sealed class SizeProperty : Amino
            {
                public override char AminoCharacter { get; } = 'F';
                public override void ApplyToStructure(Structure structure, Protein protein)
                {
                    structure.Size += protein.Value;
                }
            }
            private sealed class IdProperty : Amino
            {
                public override char AminoCharacter { get; } = 'K';
                public override void ApplyToStructure(Structure structure, Protein protein)
                {
                    // do what you need to do to Structure
                }
            }
            private sealed class StructuralType : Amino
            {
                public override char AminoCharacter { get; } = 'A';
                public override void ApplyToStructure(Structure structure, Protein protein)
                {
                    // do what you need to do to Structure
                }
            }
            private sealed class NeuralType : Amino
            {
                public override char AminoCharacter { get; } = 'B';
                public override void ApplyToStructure(Structure structure, Protein protein)
                {
                    // do what you need to do to Structure
                }
            }
        }
    }
