    import cs.system.collections.generic.Dictionary_2;
    class Main {
        static function main() {
            var dictionary = new Dictionary_2<String, Foo>();
            dictionary.Add('haxe', new Foo());
            
            // type inference works
            var implicit = null;
            dictionary.TryGetValue('haxe', implicit);
            trace(implicit);
            
            // this also works
            var explicit:Foo = null;
            dictionary.TryGetValue('haxe', explicit);
            trace(explicit);
        }
    }
    class Foo {
        public function new() {}
    }
